using CRM.DTOs.CustomerDTOs;

namespace CRM.AppWebBlazor.Data
{
    public class CustomerService
    {
        readonly HttpClient _httpClientCRM;

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientCRM = httpClientFactory.CreateClient("CRMAPI");
        }

        public async Task<SearchResultCustomerDTO> Search(SearchQueryCustomerDTO searchQueryCustomerDTO)
        {
            var response = await _httpClientCRM.PostAsJsonAsync("/customer/search", searchQueryCustomerDTO);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultCustomerDTO>();
                return result ?? new SearchResultCustomerDTO();
            }
            return new SearchResultCustomerDTO();
        }

        public async Task<GetIdResultCustomerDTO> GetById(int id)
        {
            var response = await _httpClientCRM.GetAsync("/customer/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultCustomerDTO>();
                return result ?? new GetIdResultCustomerDTO();
            }
            return new GetIdResultCustomerDTO();
        }

        public async Task<int> Create(CreateCustomerDTO createCustomerDTO)
        {
            int result = 0;
            var response = await _httpClientCRM.PostAsJsonAsync("/customer", createCustomerDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        public async Task<int> Edit(EditCustomerDTO editCustomerDTO)
        {
            int result = 0;
            var response = await _httpClientCRM.PutAsJsonAsync("/customer", editCustomerDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var response = await _httpClientCRM.DeleteAsync("/customer/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }
    }
}


