using MediatR;
using Budgeting.Domain.Notifications;

namespace Budgeting.Domain.Events.Notifications
{
     public class NotificationDeletedEvent : INotification
     {
          public NotificationDeletedEvent(Notification notification)
          {
               Notification = notification;
          }

          public Notification Notification { get; }
     }
}