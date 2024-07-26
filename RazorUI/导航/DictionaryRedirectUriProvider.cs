using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace RazorUI.导航;

/// <summary>
///		基于字典的重定向目标路径提供者。
/// </summary>
public class DictionaryRedirectUriProvider : IRedirectUriProvider, IDictionary<string, string>
{
	/// <summary>
	///		通过相对 URI 获取重定向目标 URI
	/// </summary>
	/// <param name="relative_uri"></param>
	/// <returns>可以返回相对 URI 也可以返回绝对 URI。</returns>
	/// <exception cref="Exception"></exception>
	public string GetRedirectUri(string relative_uri)
	{
		try
		{
			return _dic[relative_uri];
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			throw new Exception("此路径缺失重定向");
		}
	}

	/// <inheritdoc/>
	public void SetRedirectUri(string relative_uri, string dst_uri)
	{
		_dic[relative_uri] = dst_uri;
	}

	private Dictionary<string, string> _dic = [];

	/// <inheritdoc/>
	public void Add(string key, string value)
	{
		((IDictionary<string, string>)_dic).Add(key, value);
	}

	/// <inheritdoc/>
	public bool ContainsKey(string key)
	{
		return ((IDictionary<string, string>)_dic).ContainsKey(key);
	}

	/// <inheritdoc/>
	public bool Remove(string key)
	{
		return ((IDictionary<string, string>)_dic).Remove(key);
	}

	/// <inheritdoc/>
	public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
	{
		return ((IDictionary<string, string>)_dic).TryGetValue(key, out value);
	}

	/// <inheritdoc/>
	public string this[string key]
	{
		get
		{
			return ((IDictionary<string, string>)_dic)[key];
		}

		set
		{
			((IDictionary<string, string>)_dic)[key] = value;
		}
	}

	/// <inheritdoc/>
	public ICollection<string> Keys
	{
		get
		{
			return ((IDictionary<string, string>)_dic).Keys;
		}
	}

	/// <inheritdoc/>
	public ICollection<string> Values
	{
		get
		{
			return ((IDictionary<string, string>)_dic).Values;
		}
	}

	/// <inheritdoc/>
	public void Add(KeyValuePair<string, string> item)
	{
		((ICollection<KeyValuePair<string, string>>)_dic).Add(item);
	}

	/// <inheritdoc/>
	public void Clear()
	{
		((ICollection<KeyValuePair<string, string>>)_dic).Clear();
	}

	/// <inheritdoc/>
	public bool Contains(KeyValuePair<string, string> item)
	{
		return ((ICollection<KeyValuePair<string, string>>)_dic).Contains(item);
	}

	/// <inheritdoc/>
	public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
	{
		((ICollection<KeyValuePair<string, string>>)_dic).CopyTo(array, arrayIndex);
	}

	/// <inheritdoc/>
	public bool Remove(KeyValuePair<string, string> item)
	{
		return ((ICollection<KeyValuePair<string, string>>)_dic).Remove(item);
	}

	/// <inheritdoc/>
	public int Count
	{
		get
		{
			return ((ICollection<KeyValuePair<string, string>>)_dic).Count;
		}
	}

	/// <inheritdoc/>
	public bool IsReadOnly
	{
		get
		{
			return ((ICollection<KeyValuePair<string, string>>)_dic).IsReadOnly;
		}
	}

	/// <inheritdoc/>
	public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
	{
		return ((IEnumerable<KeyValuePair<string, string>>)_dic).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)_dic).GetEnumerator();
	}
}
