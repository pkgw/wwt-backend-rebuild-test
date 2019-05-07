<%@ Page Language="C#" ContentType="image/png" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="WWTWebservices" %>
<%
    string query = Request.Params["Q"];
    string[] values = query.Split(',');   
    int level = Convert.ToInt32(values[0]);
    int tileX = Convert.ToInt32(values[1]);
    int tileY = Convert.ToInt32(values[2]);
    string file = "2massoctset";
	
	string wwtTilesDir = ConfigurationManager.AppSettings["WWTTilesDir"];

	
    if (level < 8)
    {
        Response.ContentType = "image/png";
        Stream s = PlateTilePyramid.GetFileStream(String.Format(wwtTilesDir  + "\\{0}.plate",file), level, tileX, tileY);
        int length = (int)s.Length;
        byte[] data = new byte[length];
        s.Read(data, 0, length);
        Response.OutputStream.Write(data, 0, length);
        Response.Flush();
        Response.End();
        return;
    }
%>