using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFeReader {
    public static class ExportDatagridView {
        public static void ExportarCSV(DataGridView dataGridView) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.Filter = "Arquivo CSV (*.csv)|*.csv";
                saveFileDialog.Title = "Salvar arquivo CSV";

                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    StringBuilder sb = new StringBuilder();

                    // Escreve o cabeçalho
                    for (int i = 0; i < dataGridView.Columns.Count; i++) {
                        sb.Append(dataGridView.Columns[i].HeaderText);

                        if (i != dataGridView.Columns.Count - 1) {
                            sb.Append(",");
                        }
                    }

                    sb.AppendLine();

                    // Escreve as linhas de dados
                    foreach (DataGridViewRow row in dataGridView.Rows) {
                        for (int i = 0; i < dataGridView.Columns.Count; i++) {
                            sb.Append(row.Cells[i].Value);

                            if (i != dataGridView.Columns.Count - 1) {
                                sb.Append(",");
                            }
                        }

                        sb.AppendLine();
                    }

                    // Salva o arquivo CSV
                    File.WriteAllText(saveFileDialog.FileName, sb.ToString());

                    MessageBox.Show("Arquivo salvo com sucesso!");
                }
            }
        }
        public static void ExportarExcel(DataGridView dataGridView) {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Cria um novo arquivo Excel
            using (ExcelPackage package = new ExcelPackage()) {
                // Adiciona uma nova planilha ao arquivo
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Planilha 1");

                DataTable dt = new DataTable();
                foreach (DataGridViewColumn col in dataGridView.Columns) {
                    dt.Columns.Add(col.HeaderText);
                }
                foreach (DataGridViewRow row in dataGridView.Rows) {
                    object[] rowData = new object[dataGridView.Columns.Count];
                    for (int i = 0; i < dataGridView.Columns.Count; i++) {
                        rowData[i] = row.Cells[i].Value;
                    }
                    dt.Rows.Add(rowData);
                }
                //dataGridView.DataSource = dt;
                // Adiciona os dados do DataGridView à planilha
                worksheet.Cells["A1"].LoadFromDataTable((DataTable)dt, true);

                // Formata as células da planilha
                using (ExcelRange range = worksheet.Cells[1, 1, dataGridView.Rows.Count + 1, dataGridView.Columns.Count]) {
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                // Exibe um SaveFileDialog para que o usuário possa escolher onde salvar o arquivo
                using (SaveFileDialog sfd = new SaveFileDialog()) {
                    sfd.Filter = "Arquivos do Excel|*.xlsx";
                    sfd.FileName = "Planilha1.xlsx";
                    if (sfd.ShowDialog() == DialogResult.OK) {
                        // Salva o arquivo Excel no local escolhido pelo usuário
                        File.WriteAllBytes(sfd.FileName, package.GetAsByteArray());
                    }
                }
            }
        }

    }
}
