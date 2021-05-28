using MediatR;
using Budgeting.Domain.Notifications;

namespace Budgeting.Domain.Events.Notifications
{
     public class NotificationCreatedEvent : INotification
     {
          public NotificationCreatedEvent(Notification notification)
          {
               Notification = notification;
          }

          public Notification Notification { get; }
     }
}