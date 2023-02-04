# WindowsService
Easy extendable and testable windows service

## How to test
You are able to debug this windows service like any console application. You need just to change output type for this project to Console Application.

> Just change output type to Console Application

## How to extend

1. Create new Class Library project
2. Add reference to WinService.Common one of the following ways
   - Add reference to project WinService.Common
   - Add reference to WinService.Common.dll
3. Implement interface IWinServiceAddIn and add ExportAttribute
```
[Export(typeof(IWinServiceAddIn))]
public class CustomAddIn : IWinServiceAddIn
{
    // content of your addIn
}
```
4. Add your business logic to your addIn

## Use prepared workers
You can use one of prepared workers for your addIn.

### Periodic worker
This worker runs your method periodically with specified period
```
public void OnStart(CancellationToken cancellationToken)
{
    _worker = new PeriodicWorker(() =>
    {
        // You periodic work logic
    }, cancellationToken, period);
    _worker.DoWork();
}
```

### Event based worker
This worker runs your method once and going to infinite loop with specified delay 
```
public void OnStart(CancellationToken cancellationToken)
{
    _worker = new EventBasedWorker(() =>
    {
        // You event based work logic 
    }, cancellationToken, delay);
    _worker.DoWork();
}
```

## Contacts
Please contact [Alexander Ryabinin](mailto:ryabinin_alex@mail.ru?subject=[GitHub]%20Feedback%20or%suggestion)
if you would share any feedback or suggestion. I would be appreciate it.

Telegram: https://t.me/ryabinin_alex

## License
Logger is licensed under the MIT license.
