﻿using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise01.CustomRecyclerView.Models;
using Android.Util;
using Android.Graphics;

namespace Exercise01.CustomRecyclerView
{
    class CustomAdapter : RecyclerView.Adapter
    {
        List<Item> items;

        public CustomAdapter()
        {
        }

        public CustomAdapter(List<Item> data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here

            var id = Resource.Layout.CardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new CustomAdapterViewHolder(itemView);
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as CustomAdapterViewHolder;

            var imageAsBytes = Base64.Decode(item.Image, Base64Flags.Default);
            var imageAsBitmap = BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);

            holder.ImageViewIcon.SetImageBitmap(imageAsBitmap);
            holder.TextViewName.Text = item.Name;
            holder.TextViewVersion.Text = item.Version;
        }

        public override int ItemCount => items.Count;
    }

    public class CustomAdapterViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ImageViewIcon { get; set; }
        public TextView TextViewName { get; set; }
        public TextView TextViewVersion { get; set; }


        public CustomAdapterViewHolder(View itemView) : base(itemView)
        {
            ImageViewIcon = itemView.FindViewById<ImageView>(Resource.Id.image);
            TextViewName = itemView.FindViewById<TextView>(Resource.Id.name);
            TextViewVersion = itemView.FindViewById<TextView>(Resource.Id.version);
        }
    }
}