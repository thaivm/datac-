using System;
/// <summary>
/// Class provides method for handling change event arguments
/// </summary>
public class ColorChangedEventArgs:EventArgs 
{

	private ColorHandler.RGB mRGB;
	private ColorHandler.HSV mHSV;
    /// <summary>
    /// Do change event
    /// </summary>
    /// <param name="RGB"></param>
    /// <param name="HSV"></param>
	public ColorChangedEventArgs ( ColorHandler.RGB RGB,  ColorHandler.HSV HSV) 
	{
		mRGB = RGB;
		mHSV = HSV;
	}
    /// <summary>
    /// Get color handler RGB
    /// </summary>
	public ColorHandler.RGB RGB
	{
		get 
		{
			return mRGB;
		}
	}
    /// <summary>
    /// Get color handler HSV
    /// </summary>
	public ColorHandler.HSV HSV  
	{
		get 
		{
			return mHSV;
		}
	}
}