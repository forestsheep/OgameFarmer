using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class KeywordNotFoundInHtmlException : CannotContinueException
    {
        private const string message = "返回的页面中未找到期待的关键字:{0}";

        private string xpath;
        internal KeywordNotFoundInHtmlException(string xpath)
        {
            this.xpath = xpath;
        }
        public override string ToString()
        {
            return string.Format(message, xpath);
        }
    }
}
