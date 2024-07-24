namespace RazorUI;

/// <summary>
///		用于给 html 标签提供 id 字符串。
/// </summary>
public class IDStringProvider
{
	/// <summary>
	///		构造函数。
	/// </summary>
	public IDStringProvider()
	{
		lock (_id_lock)
		{
			IdString = $"ID{_id++}";
		}
	}

	private static object _id_lock = new();
	private static ulong _id = 0;

	/// <summary>
	///		id 字符串。可以用来设置 html 标签的 id 属性。
	///		在本对象生命周期内，此属性不会改变。
	/// </summary>
	public string IdString { get; }
}
