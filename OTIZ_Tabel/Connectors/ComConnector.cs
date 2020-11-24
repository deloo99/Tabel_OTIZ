using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OTIZ_Tabel.Connectors;
using OTIZ_Tabel.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using V83;

namespace OTIZ_Tabel
{
    internal class ComConnector : BaseConnector
    {
        private COMConnector _connector;
        private dynamic _connection;
        private List<Employe> _employes;


        public override ConnectorType ConnectorType => ConnectorType.ComConnector; 


        public override void Connection()
        {
            ConnectionStatus = ConnectionStatus.Progress;
            try
            {
                try
                {
                    _connector = new COMConnector();
                }
                catch
                {
                    throw new Exception("Ошибка инициализация компонента ActiveX \"V83.COMConnector\"...");
                }
                try
                {
                    string connectionString = $"{Settings.ComConnectionString}Usr=\"{Settings.UserName}\";Pwd =\"{Settings.UserPassword}\"";
                    _connection = _connector.Connect(connectionString);
                }
                catch
                {
                    throw new Exception("Ошибка подключения к 1С.");
                }
                try
                {
                    if (Properties.Settings.Default.Preload)
                        LoadEmployes(true);
                }
                catch
                {
                    throw new Exception("Ошибка при получении списка сотрудников.");
                }

                ConnectionStatus = ConnectionStatus.Connected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConnectionStatus = ConnectionStatus.Disconnected;
            }
        }
        public override void TestConnection(LoggerForm logger, string connectionString, string login, string password)
        {
            //тестирование соединения происходит с использованием библиотек VisualBasic
            //это необходимо для получения человекочитаемых сообщений при исключениях.
            try
            {
                logger.DefaultBoldText("Тестовое подключение к базе 1С через COM порт.\r\n\r\n");

                logger.DefaultText("Инициализация компонента ActiveX \"V83.COMConnector\"...");
                object COMConnector = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("V83.COMConnector"));
                if (logger.IsClosed) return;
                logger.SuccessText(" ✓ ВЫПОЛНЕНО\r\n");

                logger.DefaultText("Установка соединения с 1С...");
                connectionString = $"{connectionString}Usr=\"{login}\";Pwd =\"{password}\"";
                _ = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(COMConnector, null, "Connect", new object[1] { connectionString }, null, null, null));
                if (logger.IsClosed) return;
                logger.СustomText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);

                logger.СustomText("\r\nТестирование успешно завершено!", Color.Black, FontStyle.Regular);
            }
            catch (Exception ex)
            {
                logger.ExceptionText(ex);
            }
            finally
            {
                logger.Complete();
            }
        }
        public override void Disonnection()
        {
            Marshal.ReleaseComObject(_connector);
            ConnectionStatus = ConnectionStatus.Disconnected;
        }
        public override void SetWorkingHours(LoggerForm logger)
        {
            static string NormalizeCode(string source)
                => "-".PadLeft(5, '0') + source.PadLeft(5, '0');
            static string NormalizeCode2(string source)
                => "-".PadLeft(5, '0') + source.PadLeft(4, '0');

            try
            {
                logger.DefaultBoldText("Проставление рабочих часов сотрудникам.\r\n\r\n");
                logger.DefaultText("Подключение к таблице EXCEL...");
                var worksheet = (Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
                logger.SuccessText(" ✓ ВЫПОЛНЕНО\r\n");

                if (!Settings.Preload)
                {
                    logger.DefaultText("Получение списка сотрудников...");
                    LoadEmployes();
                    logger.SuccessText(" ✓ ВЫПОЛНЕНО\r\n");
                }

                logger.DefaultText("\r\nПроставление часов:\r\n");
                for (int row = Settings.FirstRow; row <= Settings.LastRow; row++)
                {
                    if (logger.IsClosed) return;
                    string code = Convert.ToString(worksheet.Cells[row, Settings.CodeCol].Value);
                    if (code.IsInt())
                    {
                        code = NormalizeCode(code);
                        var employe = _employes.Where(x => x.Code == code).FirstOrDefault();
                        if (employe == null)
                        {
                            code = NormalizeCode2(Convert.ToString(worksheet.Cells[row, Settings.CodeCol].Value));
                            employe = _employes.Where(x => x.Code == code).FirstOrDefault();
                        }

                        logger.DefaultText($"{row} стр.  [{code}]");
                        if (employe != null)
                        {
                            string name = Convert.ToString(worksheet.Cells[row, Settings.FioCol].Value);
                            if (employe.FIO.ToLower() == name.ToLower())
                            {
                                logger.DefaultText($" {employe.FIO}");
                                foreach (dynamic record in (IEnumerable)_connection.ТСМ.ПолучитьВремя(Settings.FirstDate, Settings.LastDate, employe.Data))
                                {
                                    employe.Normal += record.Явки;
                                    employe.Night += record.Ночные;
                                    employe.Holiday += record.Праздники;
                                }
                                worksheet.Cells[row, Settings.NormalCol] = employe.Normal + employe.Night + employe.Holiday;
                                worksheet.Cells[row, Settings.NightCol] = employe.Night;
                                worksheet.Cells[row, Settings.HolidayCol] = employe.Holiday;
                                logger.SuccessText(" ✓ ВЫПОЛНЕНО\r\n");
                            }
                            else
                            {
                                logger.DefaultText($" {employe.FIO} != {name}");
                                logger.ErrorText($" ⚠ НЕСООТВЕТСТВИЕ ДАННЫХ\r\n");
                                worksheet.Cells[row, Settings.NormalCol] = 0;
                                worksheet.Cells[row, Settings.NightCol] = 0;
                                worksheet.Cells[row, Settings.HolidayCol] = 0;
                            }
                        }
                        else
                        {
                            logger.ErrorText($" ⚠ НЕТ ИНФОРМАЦИИ\r\n");
                            worksheet.Cells[row, Settings.NormalCol] = 0;
                            worksheet.Cells[row, Settings.NightCol] = 0;
                            worksheet.Cells[row, Settings.HolidayCol] = 0;
                        }
                    }
                    else
                    {
                        logger.DefaultText($"{row} стр.  [{code}] - ");
                        logger.GrayText(" ПРОПУЩЕНО\r\n");
                    }
                }
                logger.DefaultBoldText("\r\nВыполнение программы завершено!");
            }
            catch (Exception ex)
            {
                logger.ErrorText(" ❌ ОШИБКА\r\n");
                logger.DefaultText($"\r\nСообщение об ошибке:\r\n{ex.Message}\r\n");
            }
            finally
            {
                logger.Complete();
            }
        }


        private void LoadEmployes(bool fullTime = false)
        {
            dynamic getEmploye = fullTime
                ? _connection.ТСМ.ПолучитьСписокСотрудников(new DateTime(2010, 1, 1), DateTime.Now)
                : _connection.ТСМ.ПолучитьСписокСотрудников(Properties.Settings.Default.FirstDate, Properties.Settings.Default.LastDate);

            _employes = new List<Employe>();
            while (getEmploye.Следующий())
                _employes.Add(new Employe { Data = getEmploye.Сотрудник, FIO = getEmploye.Сотрудник.Наименование, Code = getEmploye.СотрудникКод });
        }
    }
}
