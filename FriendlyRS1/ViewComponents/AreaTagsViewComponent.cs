using DataLayer.EntityModels;
using FriendlyRS1.Repository.RepostorySetup;
using FriendlyRS1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyRS1.ViewComponents
{
    public class AreaTagsViewComponent:ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;

        public AreaTagsViewComponent(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            List<AreaTag> areaTags = (List<AreaTag>)unitOfWork.AreaTags.GetAll();
            foreach (AreaTag tag in areaTags)
            {
                selectListItems.Add(new SelectListItem(tag.Title, tag.Id.ToString()));
            }

            FeedbackVM feedbackVM = new FeedbackVM()
            {
                areaTagList = selectListItems
            };

            return View(feedbackVM);
        }
    }
}
