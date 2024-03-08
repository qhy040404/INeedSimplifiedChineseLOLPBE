using System.IO;
using System.Text.RegularExpressions;

var path = Path.Combine("C:", "ProgramData", "Riot Games", "Metadata", "league_of_legends.pbe", "league_of_legends.pbe.product_settings.yaml");
var vi_VN = "- \"vi_VN\"";

var content = File.ReadAllText(path);
if (content.Contains("- \"zh_CN\"")) return;
var index = content.IndexOf(vi_VN)+vi_VN.Length;
content = content.Insert(index, "\n    - \"zh_CN\"");
content = Regex.Replace(content, "  locale: \"\\w+\"", "  locale: \"zh_CN\"");
File.WriteAllText(path, content);