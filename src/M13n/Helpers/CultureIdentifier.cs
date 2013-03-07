namespace M13n.Helpers
{
    /// <summary>
    /// Specifies constants that define ISO 639-1 codes of names of languages 
    /// and numeric identifier based on the System.Globalization.CultureInfo 
    /// culture identifier (LCID) corresponding value.
    /// </summary>
    /// <remarks>
    /// The enumerations items defined here are the one used for the route constraints 
    /// and to generate the culture switch control.
    /// 
    /// </remarks>
    public enum CultureIdentifier
    {
        //nl = 0x0013,	// Dutch
        en = 0x0009,	// English
        fr = 0x000C,	// French
        //de = 0x0007,	// German
        es = 0x000A     // Spanish
    }

}