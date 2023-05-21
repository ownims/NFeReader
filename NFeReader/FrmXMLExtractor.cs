using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace NFeReader {
    public partial class FrmXMLExtractor : Form {
        string filePath = "";
        string fileDir = "";
        string filename = "";
        XmlDocument xmlDocument = new XmlDocument();
        XmlNamespaceManager nsmgr;
        string nfePrefix;
        string namespaceUri;
        public enum ExportFileType {
            xsl = 0,
            csv = 1
        }
        public FrmXMLExtractor() {
            InitializeComponent();
            CbExportType.Items.Clear();
            CbExportType.Items.Add(".XLS");
            CbExportType.Items.Add(".CSV");
            CbExportType.SelectedIndex = 0;
            treeView1.Nodes.Clear();
        }
        private void BtnOpenFile_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos XML|*.xml";
            openFileDialog.Title = "Selecione um arquivo XML";

            try {
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath = openFileDialog.FileName;
                    fileDir = Path.GetDirectoryName(filePath);
                    filename = Path.GetFileName(filePath);
                    label1.Text = "Caminho:" + fileDir;
                    label2.Text = "Arquivo:" + filename;
                    xmlDocument.Load(filePath);
                    nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
                    XmlNode rootNode = xmlDocument.DocumentElement;
                    if (rootNode != null) {
                        namespaceUri = xmlDocument.DocumentElement.GetNamespaceOfPrefix(rootNode.Prefix);
                        nfePrefix = "ns";
                        string pref = xmlDocument.DocumentElement.GetPrefixOfNamespace(namespaceUri);
                        nsmgr.AddNamespace(nfePrefix, xmlDocument.DocumentElement.GetNamespaceOfPrefix(pref));
                        XMLToTree();
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void XMLToTree() {
            if (xmlDocument == null || xmlDocument.DocumentElement == null) {
                return;
            }
            treeView1.Nodes.Clear();
            TreeNode rootNode = new TreeNode(xmlDocument.DocumentElement.Name);
            rootNode.Tag = GetXPath(xmlDocument.DocumentElement);
            treeView1.Nodes.Add(rootNode);
            AddNodes(rootNode, xmlDocument.DocumentElement);
            treeView1.CheckBoxes = true;
            treeView1.ExpandAll();
        }
        private void AddNodes(TreeNode parentNode, XmlNode xmlNode) {
            foreach (XmlNode childNode in xmlNode.ChildNodes) {
                XmlElement xmlElement = childNode as XmlElement;
                if (xmlElement == null) continue;

                TreeNode node = new TreeNode(xmlElement.Name);
                node.Tag = GetXPath(xmlElement);
                parentNode.Nodes.Add(node);

                if (xmlElement.HasChildNodes) {
                    AddNodes(node, xmlElement);
                }
            }
        }
        private string GetXPath(XmlNode node) {
            if (node.NodeType == XmlNodeType.Attribute) {
                return String.Format("{0}/@{1}", GetXPath(((XmlAttribute)node).OwnerElement), node.Name);
            }
            if (node.ParentNode == null) {
                return "";
            }
            return String.Format("{0}/{2}{1}", GetXPath(node.ParentNode), node.Name, GetPrefix());
        }
        private string GetPrefix() {
            if (string.IsNullOrEmpty(nfePrefix)) {
                return "";
            }
            return nfePrefix + ":";
        }
        private void CriarColunas(DataGridView dataGridView, TreeNode node) {
            // Cria as colunas da tabela com base nos nós selecionados
            XmlNode xmlNodeList = xmlDocument.SelectSingleNode(node.Tag.ToString(), nsmgr);
            if (xmlNodeList != null) {
                foreach (XmlNode xmlNode in xmlNodeList) {
                    string headerText = $"{xmlNode.ParentNode.ParentNode.Name}_{xmlNode.ParentNode.Name}";
                    if (dataGridView.Columns[headerText] == null) {
                        dataGridView.Columns.Add(headerText, headerText);
                    }
                }
            }
        }
        private void AdicionarLinha(string filePath) {
            // Carrega o arquivo XML
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            // Cria uma nova linha no DataGridView
            int index = dataGridView1.Rows.Add();

            // Percorre todos os nós da árvore
            foreach (TreeNode node in treeView1.Nodes) {
                PercorrerFilhos(node, xmlDocument, index);
            }
        }
        private void PercorrerFilhos(TreeNode node, XmlDocument xmlDocument, int rowIndex) {
            // Recupera o valor do nó
            XmlNode xmlNode = xmlDocument.SelectSingleNode(node.Tag.ToString(), nsmgr);
            string value = xmlNode?.InnerText;

            // Adiciona o valor na coluna correspondente
            string columnName = xmlNode?.Name;
            if (xmlNode != null) {
                columnName = xmlNode?.ParentNode.Name + "_" + xmlNode?.Name;
            }
            if (!string.IsNullOrEmpty(columnName) && dataGridView1.Columns.Contains(columnName)) {
                dataGridView1.Rows[rowIndex].Cells[columnName].Value = value;
            }

            // Percorre todos os nós filhos
            foreach (TreeNode childNode in node.Nodes) {
                PercorrerFilhos(childNode, xmlDocument, rowIndex);
            }
        }
        private void BtnExtractSection_Click(object sender, EventArgs e) {
            dataGridView1.Columns.Clear();
            ExibirTagsTreeView(treeView1);
            AdicionarLinha(filePath);
        }
        private void ExibirTagsTreeView(TreeView treeView) {
            foreach (TreeNode node in treeView.Nodes) {
                ExibirValorRecursivo(node);
            }
        }
        private void ExibirValorRecursivo(TreeNode node) {
            if (node.Tag != null && node.Checked) {
                XmlNode xmlNodeList = xmlDocument.SelectSingleNode(node.Tag.ToString(), nsmgr);
                if (xmlNodeList != null) {
                    foreach (XmlNode xmlNode in xmlNodeList) {
                        CriarColunas(dataGridView1, node);
                    }
                }
            }
            foreach (TreeNode childNode in node.Nodes) {
                ExibirValorRecursivo(childNode);
            }
        }
        private void ProcessarDiretorio(string diretorio) {
            // Obtém a lista de arquivos do diretório com a extensão XML
            string[] arquivos = Directory.GetFiles(diretorio, "*.xml");

            // Percorre cada arquivo e chama a função AdicionarLinha
            foreach (string arquivo in arquivos) {
                AdicionarLinha(arquivo);
            }
        }
        private void BtnExtractAll_Click(object sender, EventArgs e) {
            ProcessarDiretorio(fileDir);
        }
        private void BtnExport_Click(object sender, EventArgs e) {
            try {
                ExportFileType tipo = (ExportFileType)CbExportType.SelectedIndex;
                switch (tipo) {
                    case ExportFileType.xsl:
                        ExportDatagridView.ExportarExcel(dataGridView1);
                        break;
                    case ExportFileType.csv:
                        ExportDatagridView.ExportarCSV(dataGridView1);
                        break;
                    default:
                        break;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
