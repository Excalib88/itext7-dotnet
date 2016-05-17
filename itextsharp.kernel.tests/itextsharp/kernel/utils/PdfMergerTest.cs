using System;
using System.Collections.Generic;
using System.IO;
using Java.IO;
using NUnit.Framework;
using iTextSharp.Kernel.Pdf;
using iTextSharp.Test;

namespace iTextSharp.Kernel.Utils
{
	public class PdfMergerTest : ExtendedITextTest
	{
		public const String sourceFolder = "../../resources/itextsharp/kernel/utils/PdfMergerTest/";

		public const String destinationFolder = "test/itextsharp/kernel/utils/PdfMergerTest/";

		[TestFixtureSetUp]
		public static void BeforeClass()
		{
			CreateDestinationFolder(destinationFolder);
		}

		/// <exception cref="System.IO.IOException"/>
		/// <exception cref="System.Exception"/>
		[NUnit.Framework.Test]
		public virtual void MergeDocumentTest01()
		{
			String filename = sourceFolder + "courierTest.pdf";
			String filename1 = sourceFolder + "helveticaTest.pdf";
			String filename2 = sourceFolder + "timesRomanTest.pdf";
			String resultFile = destinationFolder + "mergedResult01.pdf";
			PdfReader reader = new PdfReader(new FileStream(filename));
			PdfReader reader1 = new PdfReader(new FileStream(filename1));
			PdfReader reader2 = new PdfReader(new FileStream(filename2));
			FileOutputStream fos1 = new FileOutputStream(resultFile);
			PdfWriter writer1 = new PdfWriter(fos1);
			PdfDocument pdfDoc = new PdfDocument(reader);
			PdfDocument pdfDoc1 = new PdfDocument(reader1);
			PdfDocument pdfDoc2 = new PdfDocument(reader2);
			PdfDocument pdfDoc3 = new PdfDocument(writer1);
			PdfMerger merger = new PdfMerger(pdfDoc3).SetCloseSourceDocuments(true);
			merger.Merge(pdfDoc, 1, 1);
			merger.Merge(pdfDoc1, 1, 1);
			merger.Merge(pdfDoc2, 1, 1);
			pdfDoc3.Close();
			CompareTool compareTool = new CompareTool();
			String errorMessage = compareTool.CompareByContent(resultFile, sourceFolder + "cmp_mergedResult01.pdf"
				, destinationFolder, "diff_");
			if (errorMessage != null)
			{
				NUnit.Framework.Assert.Fail(errorMessage);
			}
		}

		/// <exception cref="System.IO.IOException"/>
		/// <exception cref="System.Exception"/>
		[NUnit.Framework.Test]
		public virtual void MergeDocumentTest02()
		{
			String filename = sourceFolder + "doc1.pdf";
			String filename1 = sourceFolder + "doc2.pdf";
			String filename2 = sourceFolder + "doc3.pdf";
			String resultFile = destinationFolder + "mergedResult02.pdf";
			PdfReader reader = new PdfReader(new FileStream(filename));
			PdfReader reader1 = new PdfReader(new FileStream(filename1));
			PdfReader reader2 = new PdfReader(new FileStream(filename2));
			FileOutputStream fos1 = new FileOutputStream(resultFile);
			PdfWriter writer1 = new PdfWriter(fos1);
			PdfDocument pdfDoc = new PdfDocument(reader);
			PdfDocument pdfDoc1 = new PdfDocument(reader1);
			PdfDocument pdfDoc2 = new PdfDocument(reader2);
			PdfDocument pdfDoc3 = new PdfDocument(writer1);
			PdfMerger merger = new PdfMerger(pdfDoc3).SetCloseSourceDocuments(true);
			merger.Merge(pdfDoc, 1, 1).Merge(pdfDoc1, 1, 1).Merge(pdfDoc2, 1, 1).Close();
			CompareTool compareTool = new CompareTool();
			String errorMessage = compareTool.CompareByContent(resultFile, sourceFolder + "cmp_mergedResult02.pdf"
				, destinationFolder, "diff_");
			if (errorMessage != null)
			{
				NUnit.Framework.Assert.Fail(errorMessage);
			}
		}

		/// <exception cref="System.IO.IOException"/>
		/// <exception cref="System.Exception"/>
		/// <exception cref="Javax.Xml.Parsers.ParserConfigurationException"/>
		/// <exception cref="Org.Xml.Sax.SAXException"/>
		[NUnit.Framework.Test]
		public virtual void MergeDocumentTest03()
		{
			String filename = sourceFolder + "pdf_open_parameters.pdf";
			String filename1 = sourceFolder + "iphone_user_guide.pdf";
			String resultFile = destinationFolder + "mergedResult03.pdf";
			PdfReader reader = new PdfReader(new FileStream(filename));
			PdfReader reader1 = new PdfReader(new FileStream(filename1));
			FileOutputStream fos1 = new FileOutputStream(resultFile);
			PdfWriter writer1 = new PdfWriter(fos1);
			PdfDocument pdfDoc = new PdfDocument(reader);
			PdfDocument pdfDoc1 = new PdfDocument(reader1);
			PdfDocument pdfDoc3 = new PdfDocument(writer1);
			pdfDoc3.SetTagged();
			new PdfMerger(pdfDoc3).Merge(pdfDoc, 2, 2).Merge(pdfDoc1, 7, 8).Close();
			pdfDoc.Close();
			pdfDoc1.Close();
			CompareTool compareTool = new CompareTool();
			String errorMessage = "";
			String contentErrorMessage = compareTool.CompareByContent(resultFile, sourceFolder
				 + "cmp_mergedResult03.pdf", destinationFolder, "diff_");
			String tagStructErrorMessage = compareTool.CompareTagStructures(resultFile, sourceFolder
				 + "cmp_mergedResult03.pdf");
			errorMessage += tagStructErrorMessage == null ? "" : tagStructErrorMessage + "\n";
			errorMessage += contentErrorMessage == null ? "" : contentErrorMessage;
			if (!errorMessage.IsEmpty())
			{
				NUnit.Framework.Assert.Fail(errorMessage);
			}
		}

		/// <exception cref="System.IO.IOException"/>
		/// <exception cref="System.Exception"/>
		/// <exception cref="Javax.Xml.Parsers.ParserConfigurationException"/>
		/// <exception cref="Org.Xml.Sax.SAXException"/>
		[NUnit.Framework.Test]
		public virtual void MergeDocumentTest04()
		{
			String filename = sourceFolder + "pdf_open_parameters.pdf";
			String filename1 = sourceFolder + "iphone_user_guide.pdf";
			String resultFile = destinationFolder + "mergedResult04.pdf";
			PdfReader reader = new PdfReader(new FileStream(filename));
			PdfReader reader1 = new PdfReader(new FileStream(filename1));
			FileOutputStream fos1 = new FileOutputStream(resultFile);
			PdfWriter writer1 = new PdfWriter(fos1);
			PdfDocument pdfDoc = new PdfDocument(reader);
			PdfDocument pdfDoc1 = new PdfDocument(reader1);
			PdfDocument pdfDoc3 = new PdfDocument(writer1);
			pdfDoc3.SetTagged();
			PdfMerger merger = new PdfMerger(pdfDoc3).SetCloseSourceDocuments(true);
			IList<int> pages = new List<int>();
			pages.Add(3);
			pages.Add(2);
			pages.Add(1);
			merger.Merge(pdfDoc, pages);
			IList<int> pages1 = new List<int>();
			pages1.Add(5);
			pages1.Add(9);
			pages1.Add(4);
			pages1.Add(3);
			merger.Merge(pdfDoc1, pages1);
			merger.Close();
			CompareTool compareTool = new CompareTool();
			String errorMessage = "";
			String contentErrorMessage = compareTool.CompareByContent(resultFile, sourceFolder
				 + "cmp_mergedResult04.pdf", destinationFolder, "diff_");
			String tagStructErrorMessage = compareTool.CompareTagStructures(resultFile, sourceFolder
				 + "cmp_mergedResult04.pdf");
			errorMessage += tagStructErrorMessage == null ? "" : tagStructErrorMessage + "\n";
			errorMessage += contentErrorMessage == null ? "" : contentErrorMessage;
			if (!errorMessage.IsEmpty())
			{
				NUnit.Framework.Assert.Fail(errorMessage);
			}
		}
	}
}
