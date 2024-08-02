// namespace F4lang.Builder.T1.Tests.Framework.Factories;

// using System.Diagnostics.CodeAnalysis;
// using Microsoft.Extensions.Options;
// using F4lang.Builder.T1.Tests.Framework.Abstractions;
// using F4lang.Builder.Config;
// using Platform.Markets.Foghorn.Common.Models;
// using F4lang.Builder.T1.Tests.Framework.Factories;

// [ExcludeFromCodeCoverage]
// internal class OptionsFactory : IFactory<IOptions<FoghornSettings>>
// {
//   private readonly IFactory<RetrySettings> _retrySettingsFactory = new RetrySettingsFactory();

//   public IOptions<FoghornSettings> Create()
//   {
//     var options = Options.Create<FoghornSettings>(new FoghornSettings
//     {
//       SettingsCacheDurationSeconds = 3,
//       KafkaSettings = new() { Host = "" },
//       RetrySettings = _retrySettingsFactory.Create()
//     });
//     return options;
//   }
// }
