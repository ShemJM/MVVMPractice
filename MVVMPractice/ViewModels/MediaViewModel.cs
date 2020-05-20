using System.Collections.Generic;

namespace MVVMPractice
{
    public class MediaViewModel : SideMenuPageViewModel
    {
        public MediaViewModel()
        {
            Title = "Media";
            Pages = new List<PageViewModel>()
            {
                new ImagesViewModel(),
                new VideosViewModel()
            };
            SelectedPage = Pages[0];
        }
    }
}
