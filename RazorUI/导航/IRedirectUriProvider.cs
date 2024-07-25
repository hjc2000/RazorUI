namespace RazorUI.导航;

/// <summary>
///		重定向目标 URI 提供者。
/// </summary>
public interface IRedirectUriProvider
{
	/// <summary>
	///		传入相对 URI 获取要被重定向到的目标地址的相对 URI。
	/// </summary>
	/// <param name="relative_uri"></param>
	/// <returns></returns>
	string GetRedirectUri(string relative_uri);
}
