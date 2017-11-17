package main

import (
	"bytes"
	"crypto/aes"
	"crypto/cipher"
	b64 "encoding/base64"
	"fmt"
)

func main() {
	text := []byte("fan123fdsajfkldsjak_8")
	key := []byte("sfe023f_9fd&fwfl")

	encode, err := Encrypt(text, key)
	fmt.Println("encode:", encode)
	fmt.Println("err:", err)

	uEnc := b64.StdEncoding.EncodeToString([]byte(encode))
	fmt.Println("uEncerr:", uEnc)
 

}

func Encrypt(plantText, key []byte) ([]byte, error) {
	block, err := aes.NewCipher(key) //选择加密算法
	if err != nil {
		return nil, err
	}
	fmt.Println("block:", block)
	plantText = PKCS7Padding(plantText, block.BlockSize())

	blockModel := cipher.NewCBCEncrypter(block, key)

	ciphertext := make([]byte, len(plantText))

	blockModel.CryptBlocks(ciphertext, plantText)
	return ciphertext, nil
}

func PKCS7Padding(ciphertext []byte, blockSize int) []byte {
	padding := blockSize - len(ciphertext)%blockSize
	padtext := bytes.Repeat([]byte{byte(padding)}, padding)
	return append(ciphertext, padtext...)
}
