<%@ Page Language="C#" ContentType="application/octet-stream" CodeFile="DemMars.aspx.cs" Inherits="WWTMVC5.WWTWeb.DemMars" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="WWTWebservices" %>
<%

    string query = Request.Params["Q"];
    string[] values = query.Split(',');   
    int level = Convert.ToInt32(values[0]);
    int tileX = Convert.ToInt32(values[1]);
    int tileY = Convert.ToInt32(values[2]);

    if (level < 18)
    {
    //    Response.ContentType = "image/png";

        UInt32 index = ComputeHash(level, tileX, tileY) % 400;

        Stream s = PlateFile2.GetFileStream(String.Format(@"\\wwt-mars\marsroot\dem\marsToastDem_{0}.plate", index), -1, level, tileX, tileY);
        
        if (s == null || (int)s.Length == 0)
        {
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.Write("No image");
            Response.End();
            return;
        }

        int length = (int)s.Length;
        byte[] data = new byte[length];
        s.Read(data, 0, length);
        Response.OutputStream.Write(data, 0, length);
        Response.Flush();
        Response.End();
        return;
    }

%>