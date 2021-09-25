using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace softlotery.Integrations
{
	public class HttpHelper
	{
		private const string BaseUrl = "ESCREVA SUA URL";
		private readonly HttpClient _client;

		public HttpHelper(HttpClient client)
		{
			_client = client;
		}

		public async Task<List<TResponse>> GetAllAsync<TResponse>()
		{
			var httpResponse = await _client.GetAsync(BaseUrl);

			if (!httpResponse.IsSuccessStatusCode)
			{
				throw new Exception("Erro na requisicao!.");
			}

			var content = await httpResponse.Content.ReadAsStringAsync();
			var tasks = JsonConvert.DeserializeObject<List<TResponse>>(content);

			return tasks;
		}

		public async Task<TResponse> GetTodoAsync<TResponse>(int id)
		{
			var httpResponse = await _client.GetAsync($"{BaseUrl}{id}");

			if (!httpResponse.IsSuccessStatusCode)
			{
				throw new Exception("Erro na requisicao!.");
			}

			var content = await httpResponse.Content.ReadAsStringAsync();
			var todoItem = JsonConvert.DeserializeObject<TResponse>(content);

			return todoItem;
		}

		public async Task<TResponse> CreateTodoAsync<TRequest, TResponse>(TRequest body)
		{
			var content = JsonConvert.SerializeObject(body);
			var httpResponse = await _client.PostAsync(BaseUrl, new StringContent(content, Encoding.UTF8, "application/json"));

			if (!httpResponse.IsSuccessStatusCode)
			{
				throw new Exception("Erro na requisicao!.");
			}

			var createdTask = JsonConvert.DeserializeObject<TResponse>(await httpResponse.Content.ReadAsStringAsync());
			return createdTask;
		}

		public async Task<TResponse> UpdateTodoAsync<TRequest, TResponse>(TRequest id, TRequest body)
		{
			var content = JsonConvert.SerializeObject(body);
			var httpResponse = await _client.PutAsync($"{BaseUrl}{id}", new StringContent(content, Encoding.UTF8, "application/json"));

			if (!httpResponse.IsSuccessStatusCode)
			{
				throw new Exception("Erro na requisicao!.");
			}

			var createdTask = JsonConvert.DeserializeObject<TResponse>(await httpResponse.Content.ReadAsStringAsync());
			return createdTask;
		}

		public async Task DeleteTodoAsync(int id)
		{
			var httpResponse = await _client.DeleteAsync($"{BaseUrl}{id}");

			if (!httpResponse.IsSuccessStatusCode)
			{
				throw new Exception("Erro na requisicao!.");
			}
		}
	}
}
