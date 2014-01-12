using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace GalaxyFarmer
{
    class BallListInfo : PageInfo
    {
        #region const
        private const string PAGE_NAME = "overview.php";
        private const string XPATH_BALL_LIST = "/html/body/div[2]/center/table[2]/tbody/tr/td/center/table/tbody/tr/td[2]/select";
        #endregion

        private BallListCommander ballListCommander;

        internal BallListInfo(BallListCommander ballListCommander)
        {
            this.ballListCommander = ballListCommander;
        }

        public void AccessSite()
        {
            HttpAccesser ha = HttpAccesser.GetInstance();
            ha.AccessUrl = UrlUtil.GetUrl(PAGE_NAME);
            ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
            ha.Access();
        }

        public void AnalyzResponse()
        {
            UnExpectPageController.Varify();
            HtmlAnalyzer htmlAnalyzer = new HtmlAnalyzer();
            htmlAnalyzer.Load();
            HtmlNode hn_ball = htmlAnalyzer.AnalyzeNode(XPATH_BALL_LIST);
            ballListCommander.Messager.BallList = new List<Ball>();
            //星球列表
            foreach (HtmlNode hn in hn_ball.ChildNodes)
            {
                if ("option".Equals(hn.Name))
                {
                    Ball ball = new Ball();
                    Regex rx = new Regex("\\w*(?=\\&nbsp;)");
                    Match m = rx.Match(hn.InnerText);
                    if (m.Value != null)
                    {
                        ball.Name = m.Value;
                    }
                    else
                    {
                        ball.Name = "Unknow";
                    }
                    rx = new Regex("(?<=\\&nbsp;\\[).*(?=\\]\\&nbsp;\\&nbsp;)");
                    m = rx.Match(hn.InnerText);
                    if (m.Value != null)
                    {
                        ball.Location = ConvertUtil.String2Coordinate(m.Value);
                    }
                    else
                    {
                        ball.Location = ConvertUtil.String2Coordinate("0:0:0");
                    }
                    foreach (HtmlAttribute ha in hn.Attributes)
                    {
                        if ("value".Equals(ha.Name))
                        {
                            ball.Prama = ha.Value.Replace("&amp;", "&");
                        }
                    }
                    ballListCommander.Messager.BallList.Add(ball);
                }
            }
        }
    }

}
