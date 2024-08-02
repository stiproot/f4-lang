using Microsoft.Extensions.DependencyInjection;
using F4lang.Fns;

await WorkItemYmlTranslation.RunAsync();

// const bool loadDocs = false;
// if(loadDocs) await InitDocLoader.LoadAsync();

// var provider = ServiceCollectionFactory.Create()
//     .AddSlowCoreServices()
//     .AddSlowConfiguration()
//     .AddMappingRules()
//     .AddCachingServices()
//     .BuildServiceProvider();

// var fileReader = provider.GetService<IFileReader>()!;

// var content = await fileReader.ReadAllTextAsync("~/f4lang/src/F4lang.Core.Console/.input/wis/causal/correct.yml");

// Console.WriteLine(content);

// var jsn = YmlTranslator.YamlToJson(content);

// Console.WriteLine(jsn);


// var agntMetadataLoader = provider.GetService<IAgntMetadataLoader>();
// var meta = await agntMetadataLoader!.LoadJsnAsync("~/f4lang/src/F4lang.Core.Console/.metadata/wis/wi.meta.json");

// var agntManagerInvoker = provider.GetService<IAgntManagerInvoker>()!;

// var qry = new AgntManagerQry 
// { 
//     RawTxtQry = """

//     I would like you to translate some work items for me.

//     The .yml file containing the work item hierachy can be found here:
//     `~/f4lang/src/F4lang.Core.Console/.input/wis/causal/causal-models-refined.min.yml`.

//     Additional work item information:
//     - parent id: "1173362",
//     - tags: "Reboot",
//     - area path: "Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team"
//     - iteration path: "Software\\Non-Aligned\\Integrated Solutions, Sports and AI\\Teams\\Cyberdyne Project Team"

//     Use the .yml content and the aditional information to create a json paylaod.

//     Write your output file to this location `~/f4lang/src/F4lang.Lab/output/`.
//     """,
// };

// var res = await agntManagerInvoker.ManageAsync(meta, qry);

// Console.WriteLine(res.RawTxtRes);