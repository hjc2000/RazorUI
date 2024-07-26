namespace RazorUI.导航;

/// <summary>
///		重定向目标 URI 提供者。
/// </summary>
public interface IRedirectUriProvider
{
	/// <summary>
	///		获取指定的相对 URI 的重定向目标 URI。
	/// </summary>
	/// <param name="relative_uri"></param>
	/// <returns></returns>
	string GetRedirectUri(string relative_uri);

	/// <summary>
	///		为指定的相对 URI 设置重定向的目标 URI。
	/// </summary>
	/// <param name="relative_uri"></param>
	/// <param name="dst_uri"></param>
	void SetRedirectUri(string relative_uri, string dst_uri);
}
