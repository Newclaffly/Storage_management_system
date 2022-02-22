using OfficeOpenXml;
using STRM_M.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STRM_M.Controllers
{
    public class ManagementsController : Controller
    {
        STRMEntities db = new STRMEntities(); // declare goaldbal Database

        // GET: Managements
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult management_overview()
        {
            return View();
        }

        public ActionResult management_inf()
        {
            return View();
        }

        public ActionResult transaction()
        {
            return View();
        }

        public ActionResult management_business() // MA_BUSINESS
        {
            return View();
        }

        public ActionResult upload_manual_data() // manul upload data
        {
            return View();
        }
        public ActionResult ajax_getmanagement_business()
        {
            var data = db.tb_biz.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult management_storage_inf() // ma_storage_inf
        {
            return View();
        }

        public ActionResult ajax_get_management_storage_inf() // ma_storage_inf
        {
            var data = db.sp_display_storage_decode().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ajax_get_all_tran_tran()
        {
            var data = db.sp_display_storage_inf().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult manual_upload_data(FormCollection formCollection, string valueINeeds)
        //{
        //    try
        //    {
        //        var tb_temp_manual_transaction_LIST = new List<tb_temp_maual_data>();

        //        if (Request != null)
        //        {
        //            HttpPostedFileBase file = Request.Files["UploadedFile_manual"];
        //            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
        //            {
        //                string fileName = file.FileName;
        //                string fileContentType = file.ContentType;
        //                byte[] fileBytes = new byte[file.ContentLength];
        //                var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
        //                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //                using (var package = new ExcelPackage(file.InputStream))
        //                {
        //                    var currentSheet = package.Workbook.Worksheets;
        //                    var workSheet = package.Workbook.Worksheets["TEMPLATE_MANUAL_HTPS"];
        //                    var noOfCol = workSheet.Dimension.End.Column;
        //                    //var noOfRow = workSheet.Dimension.End.Row;
        //                    var noOfRow = workSheet.Cells.Where(cell => !string.IsNullOrEmpty(cell.Value?.ToString() ?? string.Empty)).LastOrDefault().End.Row;

        //                    for (int rowIterator = 1; rowIterator <= noOfRow; rowIterator++)
        //                    {
        //                        // Temp manual transacion
        //                        var data_temp_manual_transaction = new tb_transaction();

        //                        data_temp_manual_transaction.LOT_NO = workSheet.Cells[rowIterator, 4]?.Value?.ToString();//HTPS
        //                        data_temp_manual_transaction.PART_CODE = workSheet.Cells[rowIterator, 6]?.Value?.ToString();//HTPS
        //                        data_temp_manual_transaction.LOC_ID = workSheet.Cells[rowIterator, 3]?.Value?.ToString();//HTPS
        //                        data_temp_manual_transaction.QUANTITY = workSheet.Cells[rowIterator, 7]?.Value?.ToString();//HTPS
        //                        data_temp_manual_transaction.OPE_NAME = workSheet.Cells[rowIterator, 34]?.Value?.ToString();//HTPS
        //                        data_temp_manual_transaction.HOLD_DESC = workSheet.Cells[rowIterator, 34]?.Value?.ToString();//HTPS


        //                        //DateTime now = DateTime.Now;
        //                        //data_temp_manual_transaction.UPDATE_DATE = now;
        //                        //data_temp_manual_transaction.UPDATE_BY = "SYSTEM";
        //                        //data_temp_manual_transaction.FLAG_MAT = valueINeeds;

        //                        tb_temp_manual_transaction_LIST.Add(data_temp_manual_transaction);
        //                        //    }
        //                        //}//end check if model null or not null
        //                    }//end loop for read data in excel
        //                }//end using package
        //            }//end if file null
        //        }// end if Request

        //        using (STRMEntities excelImportDBEntities = new STRMEntities())
        //        {
        //            foreach (var item in tb_temp_manual_transaction_LIST)
        //            {
        //                excelImportDBEntities.data_temp_manual_transaction.Add(item);
        //            }
        //            excelImportDBEntities.SaveChanges();
        //        }
        //    }//end try
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return View("managements_overview");
        //}//end method


    }
}