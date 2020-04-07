
using System.Text;

public class XPathConstructor
{
    public string ConstructXPathFluent(string wordsToLookup)
    {
        string[] wordsArray = wordsToLookup.Split();
        StringBuilder constructedXpath = new StringBuilder("[");
        string[] ignoredItems = { "not(self::script)" };
        foreach (var item in ignoredItems)
        {
            constructedXpath.Append($"{item} and ");
        }
        if (wordsArray.Length == 1)
        {
            return constructedXpath.Append($"[contains(normalize-space(text()),'{wordsArray[0]}')]").ToString();
        }

        constructedXpath.Append($"contains(normalize-space(text()),'{wordsArray[0]}')");
        for (int i = 1; i < wordsArray.Length; i++)
        {
            constructedXpath.Append(" and contains(normalize-space(text()),'").Append(wordsArray[i]).Append("')");
        }
        constructedXpath.Append("]");
        return constructedXpath.ToString();

    }
}