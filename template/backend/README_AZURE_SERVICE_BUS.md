# Message Broker Implementation with Azure Service Bus

This implementation demonstrates how to work with message brokers (specifically Azure Service Bus) in a .NET application using a clean architecture approach.

## Architecture Overview

The solution includes:

1. **IMessageBrokerService** - Generic interface for message broker operations
2. **FakeAzureServiceBusService** - Mock implementation that logs messages instead of publishing to Azure Service Bus
3. **Domain Events** - Events that are published to the message broker
4. **Application Handlers** - Use the message broker to publish events

## Implementation Details

### 1. Message Broker Interface
```csharp
public interface IMessageBrokerService
{
    Task PublishAsync<T>(T domainEvent, string topicName, CancellationToken cancellationToken = default) where T : INotification;
    Task PublishAsync<T>(T domainEvent, CancellationToken cancellationToken = default) where T : INotification;
}
```

### 2. Fake Implementation
The `FakeAzureServiceBusService` simulates Azure Service Bus by:
- Logging messages with structured format
- Generating unique message IDs
- Simulating async operations
- Providing detailed logging information

### 3. Domain Events Published
- **SaleCreatedEvent** → Topic: `sales-salecreated`
- **SaleModifiedEvent** → Topic: `sales-salemodified`
- **SaleCancelledEvent** → Topic: `sales-salecancelled`
- **ItemCancelledEvent** → Topic: `sales-itemcancelled`

### 4. Application Handlers
Each handler uses the Azure Service Bus service to publish events:
- `CreateSaleHandler` → Publishes `SaleCreatedEvent`
- `UpdateSaleHandler` → Publishes `SaleModifiedEvent`
- `DeleteSaleHandler` → Publishes `SaleCancelledEvent`
- `CancelItemHandler` → Publishes `ItemCancelledEvent`

## Usage Example

When you create a sale, the logs will show:
```
📨 [Azure Service Bus] Publishing message to topic 'sales-salecreated' | Message ID: {guid} | Event Type: SaleCreatedEvent | Message Body: {json}
✅ [Azure Service Bus] Successfully published message {guid} to topic 'sales-salecreated'
```

## Production Implementation

To use with real Azure Service Bus, replace `FakeAzureServiceBusService` with:

```csharp
public class AzureServiceBusService : IMessageBrokerService
{
    private readonly ServiceBusClient _serviceBusClient;
    
    public async Task PublishAsync<T>(T domainEvent, string topicName, CancellationToken cancellationToken = default) where T : INotification
    {
        var sender = _serviceBusClient.CreateSender(topicName);
        var messageBody = JsonSerializer.Serialize(domainEvent);
        var message = new ServiceBusMessage(messageBody);
        
        await sender.SendMessageAsync(message, cancellationToken);
    }
}
```

## Benefits

1. **Decoupling** - Application handlers don't need to know about specific message broker implementation
2. **Testability** - Easy to mock and test without actual Azure Service Bus
3. **Observability** - Detailed logging for monitoring and debugging
4. **Flexibility** - Can easily switch between different message broker implementations

## Dependencies

- `MediatR` for event interface
- `Microsoft.Extensions.Logging` for logging
- `System.Text.Json` for serialization 