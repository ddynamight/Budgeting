using MediatR;
using Budgeting.Domain.Notifications;

namespace Budgeting.Domain.Events.Notifications
{
     public class NotificationAccessedEvent : INotification
     {
          public NotificationAccessedEvent(Notification notification)
          {
               Notification = notification;
          }

          public Notification Notification { get; }
     }
}