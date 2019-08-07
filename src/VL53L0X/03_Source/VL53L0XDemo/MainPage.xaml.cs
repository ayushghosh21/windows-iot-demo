﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace VL53L0XDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            VL53L0X sensor = new VL53L0X();
            await sensor.InitializeAsync();

            while (true)
            {
                var dis = sensor.ReadDistance();
                Debug.WriteLine("distance : " + dis + " mm");

                //var res = sensor.Read();
                //Debug.WriteLine("ambient count : " + res.Ambient);
                //Debug.WriteLine("signal count : " + res.Signal);
                //Debug.WriteLine("distance : " + res.Distance + " mm");
                //Debug.WriteLine("status : " + res.Status);

                await Task.Delay(2000);
            }
        }
    }
}