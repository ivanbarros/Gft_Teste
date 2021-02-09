using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gft.Documentation.Notification
{
    public class NotificationContext : Notifiable
    {
        public NotificationContext() =>
            HandleConflict = true;

        public bool HandleConflict { get; set; }
    }
}
