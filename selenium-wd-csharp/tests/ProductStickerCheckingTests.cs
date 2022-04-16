using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace selenium_wd_csharp
{
    [TestFixture]
    public class ProductStickerCheckingTests : TestBase
    {
        [Test]
        public void CheckProductStickerIsOne() => app.Shop.CheckProductStickers();

    }
}
