package main

import (
	"encoding/json"
	"fmt"
	"net/http"
)

func main() {
	// Mengonsumsi API Negara
	negaraURL := "https://insw-dev.ilcs.co.id/n/negara?ur_negara=SIN"
	negaraResponse, err := http.Get(negaraURL)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}
	defer negaraResponse.Body.Close()

	var negaraData interface{}
	err = json.NewDecoder(negaraResponse.Body).Decode(&negaraData)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}

	fmt.Println("Negara Data:")
	fmt.Println(negaraData)
	fmt.Println()

	// Mengonsumsi API Pelabuhan
	pelabuhanURL := "https://insw-dev.ilcs.co.id/n/pelabuhan?kd_negara=SG&ur_pelabuhan=jur"
	pelabuhanResponse, err := http.Get(pelabuhanURL)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}
	defer pelabuhanResponse.Body.Close()

	var pelabuhanData interface{}
	err = json.NewDecoder(pelabuhanResponse.Body).Decode(&pelabuhanData)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}

	fmt.Println("Pelabuhan Data:")
	fmt.Println(pelabuhanData)
	fmt.Println()

	// Mengonsumsi API Barang
	barangURL := "https://insw-dev.ilcs.co.id/n/barang?hs_code=02044200"
	barangResponse, err := http.Get(barangURL)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}
	defer barangResponse.Body.Close()

	var barangData interface{}
	err = json.NewDecoder(barangResponse.Body).Decode(&barangData)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}

	fmt.Println("Barang Data:")
	fmt.Println(barangData)
	fmt.Println()

	// Mengonsumsi API Tarif
	tarifURL := "https://insw-dev.ilcs.co.id/n/tarif?hs_code=10079000"
	tarifResponse, err := http.Get(tarifURL)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}
	defer tarifResponse.Body.Close()

	var tarifData interface{}
	err = json.NewDecoder(tarifResponse.Body).Decode(&tarifData)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}

	fmt.Println("Tarif Data:")
	fmt.Println(tarifData)
}
