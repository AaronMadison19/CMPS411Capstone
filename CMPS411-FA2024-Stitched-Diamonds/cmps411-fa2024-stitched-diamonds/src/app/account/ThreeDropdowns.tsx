import React, { useState, useEffect } from 'react';

interface Country {
  code: string;
  name: string;
  languages: string[];
  currencies: string;
}

const ThreeDropdowns: React.FC = () => {
  const [countries, setCountries] = useState<Country[]>([]);
  const [selectedOptions, setSelectedOptions] = useState<string[]>(['', '', '']);

  useEffect(() => {
    const fetchCountries = async () => {
      try {
        const response = await fetch('https://restcountries.com/v3.1/all');
        const data = await response.json();
        const countryList: Country[] = data.map((country: any) => ({
          code: country.cca2,
          name: country.name.common,
          languages: Object.values(country.languages || []),
          currencies: Object.values(country.currencies || []).map((curr: any) => curr.name).join(', '),
        }));
        setCountries(countryList);
      } catch (error) {
        console.error('Error fetching countries:', error);
      }
    };

    fetchCountries();
  }, []);

  const handleChange = (index: number) => (event: React.ChangeEvent<HTMLSelectElement>) => {
    const newSelectedOptions = [...selectedOptions];
    newSelectedOptions[index] = event.target.value;
    setSelectedOptions(newSelectedOptions);
  };

  const selectedCountry = countries.find(country => country.code === selectedOptions[0]);

  return (
    <div>
      <h3>Location Settings</h3>
      <h5>Set where you live, what language you speak, and currency you use</h5>

      <div>
        <h4><label htmlFor="country">Region:</label></h4>
        <select id="country" value={selectedOptions[0]} onChange={handleChange(0)}>
          <option value="">Select Country</option>
          {countries.map(country => (
            <option key={country.code} value={country.code}>
              {country.name}
            </option>
          ))}
        </select>
      </div>

      <div>
        <h4><label htmlFor="language">Language:</label></h4>
        <select id="language" value={selectedOptions[1]} onChange={handleChange(1)} disabled={!selectedOptions[0]}>
          <option value="">Select your Language</option>
          {selectedCountry?.languages.map((lang: string, index: number) => (
            <option key={index} value={lang}>
              {lang}
            </option>
          ))}
        </select>
      </div>

      <div>
        <h4><label htmlFor="currency">Currency:</label></h4>
        <select id="currency" value={selectedOptions[2]} onChange={handleChange(2)} disabled={!selectedOptions[0]}>
          <option value="">Select Currency</option>
          {selectedCountry?.currencies.split(', ').map((curr: string, index: number) => (
            <option key={index} value={curr}>
              {curr}
            </option>
          ))}
        </select>
      </div>

      <div>
        {selectedOptions.map((option, index) => option && (
          <div key={index}>You selected from Dropdown {index + 1}: {option}</div>
        ))}
        <br />
        <button onClick={() => alert("Saved!")}>Save Settings</button>
      </div>
    </div>
  );
};

export default ThreeDropdowns;