﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Exercise01.CustomRecyclerView.Models
{
    class Item
    {
        public String Name { set; get; }

        public String Version { set; get; }

        public String Image { set; get; }
    }
}