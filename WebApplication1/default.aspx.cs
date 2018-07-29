using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        const string ChannelAccessToken = "請換成你自己的Channel Access Token";
        const string AdminUserId = "請換成你自己的Admin User Id";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
       
            var LiffURL = "https://testliff.azurewebsites.net/default.html"; //測試用位置

            //建立LiffApp
            var Liff = isRock.LIFF.Utility.AddLiffApp(
                ChannelAccessToken, new Uri(LiffURL), isRock.LIFF.ViewType.tall);
            //顯示建立好的 Liff App
            isRock.LineBot.Utility.PushMessage(
                AdminUserId, "Liff App 已新增 " + Liff, ChannelAccessToken);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //取得特定ChannelAccessToken名下所有的Liff Apps
            var Liff = isRock.LIFF.Utility.GetAllLiffApps(ChannelAccessToken);
            //列舉所有Liff Apps
            foreach (var item in Liff.apps)
            {
                Response.Write($"<br>liffId : {item.liffId}");
            }
        }
    }
}