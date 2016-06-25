using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Custom_RecyclerView_StaggeredGrid.mData;
using Custom_RecyclerView_StaggeredGrid.mRecycler;


namespace Custom_RecyclerView_StaggeredGrid
{
    [Activity(Label = "Custom_StaggeredGrid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private RecyclerView rv;
        private MyAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //RECYCLERVIEW
            rv = FindViewById<RecyclerView>(Resource.Id.mRecylcerID);

            //SET ITS PROPERTIES
            //MAKE IT STAGGERED
            rv.SetLayoutManager(new StaggeredGridLayoutManager(2,1));
            rv.SetItemAnimator(new DefaultItemAnimator());

            //ADAPTER
            adapter=new MyAdapter(TVShowsCollection.GetTvShows());
            rv.SetAdapter(adapter);

            //ITEMCLICK
            adapter.ItemClick += onItemClick;

        }

        void onItemClick(object sender, int pos)
        {
           Toast.MakeText(this,TVShowsCollection.GetTvShows()[pos].Name,ToastLength.Short).Show();
        }

       
    }
}

