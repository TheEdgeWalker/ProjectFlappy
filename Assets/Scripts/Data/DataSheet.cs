using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSheet<T>
{
	private Dictionary<string, T> data = new Dictionary<string, T>();

	protected DataSheet(string path)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.json"))
		{
			string json = fileInfo.OpenText().ReadToEnd();
			T row = JsonUtility.FromJson<T>(json);
			data.Add(fileInfo.Name, row);
		}
	}

	public T GetRow(string name)
	{
		T row;
		data.TryGetValue(name, out row);
		return row;
	}
}
