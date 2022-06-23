﻿using UIKit;

namespace Xunit.Runners.Maui.HeadlessRunner
{
    public class MauiTestViewController : UIViewController
    {
        Task? _task;

        public MauiTestViewController()
        {
        }

        public MauiTestViewController(Task task)
        {
            _task = task;
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (_task is not null)
                await _task;

            var runner = MauiTestApplicationDelegate.Current.Services.GetRequiredService<HeadlessTestRunner>();

            await runner.RunTestsAsync();
        }
    }
}