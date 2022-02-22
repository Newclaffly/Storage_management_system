using OfficeOpenXml;
using STRM_M.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STRM_M.Controllers
{
    public class OperationController : Controller
    {
        STRMEntities db = new STRMEntities(); // declare goaldbal Database

        // GET: Operation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult register_view()
        {
            return View();
        }
        
        public ActionResult register_view_confirm()
        {
            return View();
        }

        public ActionResult take_out_view()
        {
            return View();
        }

        public ActionResult ajax_get_all_tran()
        {
            var data = db.sp_display_storage_inf()
                        .Where(x=> x.TYPE_TRAN_NAME == "TAKE IN")
                        .ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        // VIEW TYPE SCAN

        //REGISTER
        public ActionResult register_scan_lotcard()
        {
            return View();
        }

        public ActionResult register_scan_material()
        {
            return View();
        }

        public ActionResult ajax_get_register_scan_lotcard()
        {
            var data = db.sp_display_storage_inf()
                      .Where(x => x.TYPE_TRAN_NAME == "TAKE IN")
                      .OrderByDescending(x=> x.CREATE_DATE).Take(50)
                      .ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult record_register_scan_lotcard(tb_transaction add_value)
        {
            string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["dbinlineEntities"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_register_tran";
            cmd.Parameters.AddWithValue("@LOT_NO", add_value.LOT_NO);
            cmd.Parameters.AddWithValue("@PART_CODE", add_value.PART_CODE);
            cmd.Parameters.AddWithValue("@QTY", add_value.QTY);
            cmd.Parameters.AddWithValue("@TYPE_SYSTEM_ID", add_value.TYPE_SYSTEM_ID);
            cmd.Parameters.AddWithValue("@TYPE_TRAN_ID", add_value.TYPE_TRAN_ID);
            cmd.Parameters.AddWithValue("@LOC_ID", add_value.LOC_ID);
            cmd.Parameters.AddWithValue("@CREATE_BY", add_value.CREATE_BY);
            cmd.Parameters.AddWithValue("@REGISTER_BY", add_value.REGISTER_BY);

            cnn.Open();
            object o = cmd.ExecuteNonQuery();
            cnn.Close();
            return new EmptyResult();
        }
    
        //Select material register
        public ActionResult ajax_get_register_scan_materiald(string param_name)
        {
            //var data = param_name;
            var data = db.sp_fillter_material()
                        .Where(x => x.BIZ_NAME == "HTPS" && x.MATGROUP == param_name)
                       .ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult record_register_scan_materiald(tb_transaction add_value_mat)
        {
            string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["dbinlineEntities"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_register_tran";
            cmd.Parameters.AddWithValue("@LOT_NO", add_value_mat.LOT_NO);
            cmd.Parameters.AddWithValue("@PART_CODE", add_value_mat.PART_CODE);
            cmd.Parameters.AddWithValue("@QTY", add_value_mat.QTY);
            cmd.Parameters.AddWithValue("@TYPE_SYSTEM_ID", add_value_mat.TYPE_SYSTEM_ID);
            cmd.Parameters.AddWithValue("@TYPE_TRAN_ID", add_value_mat.TYPE_TRAN_ID);
            cmd.Parameters.AddWithValue("@LOC_ID", add_value_mat.LOC_ID);
            cmd.Parameters.AddWithValue("@CREATE_BY", add_value_mat.CREATE_BY);
            cmd.Parameters.AddWithValue("@REGISTER_BY", add_value_mat.REGISTER_BY);
            cnn.Open();
            object o = cmd.ExecuteNonQuery();
            cnn.Close();
            return new EmptyResult();
        }

        // VIEW TAKE OUT
        public ActionResult take_out_scan_lotcard()
        {
            return View();
        }

        public ActionResult take_out_scan_material()
        {
            return View();
        }
        public ActionResult ajax_get_take_out_scan_lotcard()
        {
            var data = db.sp_display_storage_inf()
                        .Where(x => x.TYPE_TRAN_NAME == "TAKE OUT")
                        .OrderByDescending(x => x.CREATE_DATE).Take(50)
                        .ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult record_take_out_scan_lot_card(tb_transaction take_out_value)
        {
            string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["dbinlineEntities"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_take_out_tran";
            cmd.Parameters.AddWithValue("@LOT_NO", take_out_value.LOT_NO);
            cmd.Parameters.AddWithValue("@PART_CODE", take_out_value.PART_CODE);
            cmd.Parameters.AddWithValue("@QTY", take_out_value.QTY);
            cmd.Parameters.AddWithValue("@TYPE_SYSTEM_ID", take_out_value.TYPE_SYSTEM_ID);
            cmd.Parameters.AddWithValue("@TYPE_TRAN_ID", take_out_value.TYPE_TRAN_ID);
            cmd.Parameters.AddWithValue("@LOC_ID", take_out_value.LOC_ID);
            cmd.Parameters.AddWithValue("@CREATE_BY", take_out_value.CREATE_BY);
            cmd.Parameters.AddWithValue("@TAKE_OUT_BY", take_out_value.TAKE_OUT_BY);

            cnn.Open();
            object o = cmd.ExecuteNonQuery();
            cnn.Close();
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult record_take_out_scan_materiald(tb_transaction take_out_value_mat)
        {
            string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["dbinlineEntities"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_take_out_tran";
            cmd.Parameters.AddWithValue("@LOT_NO", take_out_value_mat.LOT_NO);
            cmd.Parameters.AddWithValue("@PART_CODE", take_out_value_mat.PART_CODE);
            cmd.Parameters.AddWithValue("@QTY", take_out_value_mat.QTY);
            cmd.Parameters.AddWithValue("@TYPE_SYSTEM_ID", take_out_value_mat.TYPE_SYSTEM_ID);
            cmd.Parameters.AddWithValue("@TYPE_TRAN_ID", take_out_value_mat.TYPE_TRAN_ID);
            cmd.Parameters.AddWithValue("@LOC_ID", take_out_value_mat.LOC_ID);
            cmd.Parameters.AddWithValue("@CREATE_BY", take_out_value_mat.CREATE_BY);
            cmd.Parameters.AddWithValue("@TAKE_OUT_BY", take_out_value_mat.TAKE_OUT_BY);

            cnn.Open();
            object o = cmd.ExecuteNonQuery();
            cnn.Close();
            return new EmptyResult();
        }

        public ActionResult ajax_get_all_location()
        {
            var data = db.sp_display_storage_decode()
                        .Select(x=> x.STORAGE_NAME_CONCAT).Distinct()
                        .ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ajax_search_get_all_lot()
        {
            var data = db.sp_display_storage_inf()
                         .Where(x => x.TYPE_TRAN_NAME == "TAKE IN")
                        .Select(x => x.LOT_NO)
                        .ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult update_takeout_finding(tb_transaction confirme_value)
        {
            string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["dbinlineEntities"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_update_takeout_finding";
            cmd.Parameters.AddWithValue("@TRAN_ID", confirme_value.TRAN_ID);
            cmd.Parameters.AddWithValue("@TYPE_TRAN_ID", confirme_value.TYPE_TRAN_ID);
            cmd.Parameters.AddWithValue("@TAKE_OUT_BY", confirme_value.TAKE_OUT_BY);

            cnn.Open();
            object o = cmd.ExecuteNonQuery();
            cnn.Close();
            return new EmptyResult();
        }

        // FINDING
        public ActionResult finding_material_table()
        {
            return View();
        }

        // FINDING
        public ActionResult report()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Export_excel_lot_hold_list()
        {
            string strConnString = @"Server=43.72.20.210;UID=iecommon;PASSWORD=iecommon1234;database=STRM";
            var objConn = new SqlConnection(strConnString);
            //var dtAdapter = new SqlDataAdapter();
            var dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("sp_report_finding_takein", objConn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@process", edit_value.process);
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            string fileName = "Inline_stock.xls";
            FileInfo template = new FileInfo(Server.MapPath("~/Content/HTPS_STRM.xlsx"));
            ExcelPackage package = new ExcelPackage(template);
            FileContentResult data;
            var workbook = package.Workbook;

            int startRows = 2;
            //*** Sheet 1
            var worksheet2 = workbook.Worksheets["LIST_IN_HTPS"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                worksheet2.Cells["A" + (i + startRows)].Value = dt.Rows[i]["TYPE_TRAN_NAME"].ToString();
                worksheet2.Cells["B" + (i + startRows)].Value = dt.Rows[i]["REGISTER_DATE"].ToString();
                worksheet2.Cells["C" + (i + startRows)].Value = dt.Rows[i]["LOT_NO"].ToString();
                worksheet2.Cells["D" + (i + startRows)].Value = dt.Rows[i]["MATNAME"]?.ToString();
                worksheet2.Cells["E" + (i + startRows)].Value = dt.Rows[i]["OPE_NAME"]?.ToString();
                worksheet2.Cells["F" + (i + startRows)].Value = dt.Rows[i]["MAN_NAME"]?.ToString();
                worksheet2.Cells["G" + (i + startRows)].Value = dt.Rows[i]["QUANTITY_CURRENT"]?.ToString();
                worksheet2.Cells["H" + (i + startRows)].Value = dt.Rows[i]["HOLD_EMP"].ToString();
                worksheet2.Cells["I" + (i + startRows)].Value = dt.Rows[i]["HOLD_DESC"].ToString();
                worksheet2.Cells["J" + (i + startRows)].Value = dt.Rows[i]["STORAGE_NAME_CONCAT"]?.ToString();
            }

            using (MemoryStream stream = new MemoryStream())
            {
                package.SaveAs(stream);
                var bytesdata = File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                data = bytesdata;
            }
            return Json(data, JsonRequestBehavior.AllowGet); //returning bytes of file data as json object
        } // end function export

        public ActionResult ajax_get_all_lot_tracking()
        {
            var data = db.sp_hold_tracking().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ajax_get_all_lot_tracking_summary()
        {
            var data = db.sp_hold_tracking_summary().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        // IMAGE PLOT
        public ActionResult image_plot()
        {
            return View();
        }

    }
}

//AJ23