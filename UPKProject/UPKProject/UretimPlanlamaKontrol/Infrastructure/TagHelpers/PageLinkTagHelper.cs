using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using UretimPlanlamaKontrol.Models;

namespace UretimPlanlamaKontrol.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes="page-model")]
    public class PageLinkTagHelper:TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;
        //viewcontext dediğimiz zaman görünüme ilişkin bütün bağlamı temsil eden bir yapıdan bahsediyoruz
        //view context ifadesi bir görünüm çalıştırıldığında o görünüme ilişkin olan bağlamı temsil eder. viewcontext içerisinde httpcontext, viewdata, tempdata, model, routedata gibi bilgileri tutabiliriz. buradaki bilgiler işlenebilir, üzerinden link vs üretilebilir. viewcontext ifadesini oluşturan yapı controllerdir bu yapıyı görünüm nesnesine devreder 
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }    //elimizdeki görünümle ilgili html özelliğinden gelen bir takım bilgiler olacak bu bilgileri de viewcontext üzerinden organize etmeye calısacağız   

        public Pagination PageModel { get; set; }

        public String? PageAction { get; set; }

        public bool PageClassesEnabled { get; set; } = false;

        public string PageClass { get; set; }=String.Empty;

        public string PageClassNormal { get; set; } = String.Empty;

        public string PageClassSelected { get; set; } = String.Empty;

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(ViewContext is not null && PageModel is not null)
            {
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                for(int i=1; i<=PageModel.TotalPages; i++)
                {
                    TagBuilder tag=new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { PageNumber = i });
                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }
                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }
                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
