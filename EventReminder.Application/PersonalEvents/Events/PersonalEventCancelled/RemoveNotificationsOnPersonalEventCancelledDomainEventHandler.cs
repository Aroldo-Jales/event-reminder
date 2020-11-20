﻿using System.Threading;
using System.Threading.Tasks;
using EventReminder.Application.Core.Abstractions.Common;
using EventReminder.Domain.Core.Events;
using EventReminder.Domain.Events;
using EventReminder.Domain.Repositories;

namespace EventReminder.Application.PersonalEvents.Events.PersonalEventCancelled
{
    /// <summary>
    /// Represents the <see cref="PersonalEventCancelledDomainEvent"/> class.
    /// </summary>
    internal sealed class RemoveNotificationsOnPersonalEventCancelledDomainEventHandler
        : IDomainEventHandler<PersonalEventCancelledDomainEvent>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IDateTime _dateTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveNotificationsOnPersonalEventCancelledDomainEventHandler"/> class.
        /// </summary>
        /// <param name="notificationRepository">The notification repository.</param>
        /// <param name="dateTime">The date and time.</param>
        public RemoveNotificationsOnPersonalEventCancelledDomainEventHandler(
            INotificationRepository notificationRepository,
            IDateTime dateTime)
        {
            _notificationRepository = notificationRepository;
            _dateTime = dateTime;
        }

        /// <inheritdoc />
        public async Task Handle(PersonalEventCancelledDomainEvent notification, CancellationToken cancellationToken) =>
            await _notificationRepository.RemoveNotificationsForEventAsync(notification.PersonalEvent, _dateTime.UtcNow);
    }
}
