﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Windows.Storage;
using ZSCY_Win10.Common;

namespace ZSCY_Win10.Data.Community
{
    public class MyFeed : ViewModelBase, IFeeds
    {
        private string remarknum { get; set; }
        public string id { get; set; }
        public Img[] photo_src { get; set; }
        public Img[] thumbnail_src { get; set; }
        public string content { get; set; }
        public string type_id { get; set; }
        public string created_time { get; set; }
        public string updated_time { get; set; }
        public string like_num { get; set; }
        public string remark_num
        {
            get
            {
                return remarknum;
            }
            set
            {
                this.remarknum = value;
                OnPropertyChanged(nameof(remark_num));
            }
        }
        public string nickname { get; set; } = Windows.Storage.ApplicationData.Current.LocalSettings.Values["Community_nickname"].ToString();
        public string headimg { get; set; } = Windows.Storage.ApplicationData.Current.LocalSettings.Values["Community_headimg_src"].ToString();


        public void GetAttributes(JObject feedsJObject)
        {
            id = feedsJObject["id"].ToString();
            content = feedsJObject["content"].ToString();
            type_id = feedsJObject["type_id"].ToString();
            created_time = feedsJObject["created_time"].ToString();
            updated_time = feedsJObject["updated_time"].ToString();
            like_num = feedsJObject["like_num"].ToString();
            remark_num = feedsJObject["remark_num"].ToString();
            string articlephotos = feedsJObject["photo_src"].ToString();
            string smallphotos = feedsJObject["thumbnail_src"].ToString();
            nickname = feedsJObject["nickname"].ToString();
            headimg = feedsJObject["user_photo"].ToString();

            if (articlephotos != "")
            {
                try
                {
                    string[] i = articlephotos.Split(new char[] { ',' }, 9);
                    if (articlephotos.EndsWith(","))
                    {
                        photo_src = new Img[i.Length - 1];
                    }
                    else
                    {
                        photo_src = new Img[i.Length];
                        thumbnail_src = new Img[i.Length];
                    }
                    for (int j = 0; j < photo_src.Length; j++)
                    {
                        if (i[j] != "")
                        {
                            if (!i[j].StartsWith(App.picstart))
                            {
                                photo_src[j] = new Img();
                                photo_src[j].ImgSrc = App.picstart + i[j];
                                photo_src[j].ImgSmallSrc = App.picstartsmall + i[j];
                            }
                            else
                            {
                                photo_src[j] = new Img();
                                photo_src[j].ImgSrc = i[j];
                                photo_src[j].ImgSmallSrc = i[j];
                            }
                        }
                        else
                        {
                            photo_src[j] = new Img();
                            photo_src[j].ImgSrc = photo_src[j].ImgSmallSrc = "";
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);

                }
            }
        }
    }
}
