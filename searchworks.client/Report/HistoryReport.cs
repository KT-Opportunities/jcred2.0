﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using searchworks.client.Models;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace searchworks.client.Report
{
    public class HistoryReport
    {
        #region Declaration

        //DataRow dr = GetValue("SELECT EmployeeId, (FirstName + ' ' + LastName) Name FROM Employees");
        private int _totalColumn = 3;

        private Document _document;
        private Font _fontStyle;
        private PdfPTable _pdfTable = new PdfPTable(3);
        private PdfPCell _pdfPCell;
        private MemoryStream _memoryStream = new MemoryStream();
        private List<search_history> _Histories = new List<search_history>();
        #endregion Declaration

        public byte[] PrepareReport(List<search_history> histories)
        {
            _Histories = histories;
            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);

            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Calibri", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);

            _document.Open();
            _pdfTable.SetWidths(new float[] { 50f, 50f, 50f });
            #endregion

            this.ReportHeader();
            this.ReportBody();
            this.ReportFooter();
            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();
        }

        private void ReportHeader()
        {
            Image image = Image.GetInstance(HttpContext.Current.Server.MapPath("~/Content/images/bglogo.png"));
            image.ScaleToFit(300f, 300f);
            _fontStyle = FontFactory.GetFont("Calibri", 16f, 1);
            _pdfPCell = new PdfPCell(image);
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = Rectangle.BOX;
            _pdfPCell.Padding = 5;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Calibri", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Verification Report", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = Rectangle.BOX;
            _pdfPCell.Padding = 5;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _pdfTable.CompleteRow();

            foreach (search_history his in _Histories)
            {
                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase("Name of Individual/Company:", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(his.applicant_Fname, _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase("Identity/Registration Number:", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(his.id_Number, _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Calibri", 12f, 1);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = _totalColumn;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase("Requested by:", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(his.applicant_Lname, _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase("User:", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 5;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(his.account_user, _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase("Date of Request:", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(his.application_date.ToString(), _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase("Date Completed:", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase("Reason:", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(his.status, _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.Border = 0;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Padding = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();
            }
        }

        private void ReportBody()
        {
            #region Table header

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Check Requested:", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.PaddingBottom = 20;
            _pdfPCell.PaddingTop = 5;
            _pdfPCell.PaddingLeft = 5;
            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Result:", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.PaddingBottom = 20;
            _pdfPCell.PaddingTop = 5;
            _pdfPCell.PaddingLeft = 5;

            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Summary:", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.PaddingBottom = 20;
            _pdfPCell.PaddingTop = 5;
            _pdfPCell.PaddingLeft = 5;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Check Requested:", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.PaddingBottom = 20;
            _pdfPCell.PaddingTop = 5;
            _pdfPCell.PaddingLeft = 5;
            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Result:", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.PaddingBottom = 20;
            _pdfPCell.PaddingTop = 5;
            _pdfPCell.PaddingLeft = 5;

            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Summary:", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.PaddingBottom = 20;
            _pdfPCell.PaddingTop = 5;
            _pdfPCell.PaddingLeft = 5;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Check Requested:", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.PaddingBottom = 20;
            _pdfPCell.PaddingTop = 5;
            _pdfPCell.PaddingLeft = 5;
            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Result:", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.PaddingBottom = 20;
            _pdfPCell.PaddingTop = 5;
            _pdfPCell.PaddingLeft = 5;

            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Summary:", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.PaddingBottom = 20;
            _pdfPCell.PaddingTop = 5;
            _pdfPCell.PaddingLeft = 5;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();

            #endregion

            //#region Table body

            //_fontStyle = FontFactory.GetFont("Calibri", 8f, 0);

            //search_history history = new search_history();

            //    _pdfPCell = new PdfPCell(new Phrase("Dawn", _fontStyle));
            //    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //    _pdfPCell.BackgroundColor = BaseColor.WHITE;
            //    _pdfTable.AddCell(_pdfPCell);

            //    _pdfPCell = new PdfPCell(new Phrase(history.applicant_Lname, _fontStyle));
            //    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //    _pdfPCell.BackgroundColor = BaseColor.WHITE;
            //    _pdfTable.AddCell(_pdfPCell);

            //_pdfTable.CompleteRow();

            //#endregion
        }

        private void ReportFooter()
        {
            _fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("End of Validation Report", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.BackgroundColor = new BaseColor(255, 242, 204);
            _pdfPCell.Padding = 3;
            _pdfPCell.Border = 1;
            _pdfPCell.Colspan = _totalColumn;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("Please contact Sebetsa Background Checks with any queries on 011 051 6147", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.BackgroundColor = new BaseColor(255, 242, 204);
            _pdfPCell.Padding = 5;
            _pdfPCell.Border = 2;
            _pdfPCell.Colspan = _totalColumn;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
        }
    }
}