﻿using PlainCQRS.Core.Events;
using Application.Coach.Events;
using Notification.Abstractions;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Notification
{
    public class TrainingCreatedEventHandler : IEventHandlerAsync<TrainingCreated>
    {
        private readonly IOptions<SendGridConfiguration> sendGridConfiguration;

        public TrainingCreatedEventHandler(IOptions<SendGridConfiguration> sendGridConfiguration)
        {
            this.sendGridConfiguration = sendGridConfiguration;
        }


        public async Task HandleAsync(TrainingCreated @event, CancellationToken cancellationToken = default)
        {
            var apiKey = sendGridConfiguration.Value.SendGridKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(sendGridConfiguration.Value.EmailAdress, @event.CoachName);
            var subject = "New Training";
            var to = new EmailAddress(@event.RunnerEmailAddress, "Runner");
            var htmlContent = $@"<span>{@event.TrainingDetail}<span>"; // todo
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
