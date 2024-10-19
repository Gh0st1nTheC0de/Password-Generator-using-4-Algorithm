import random
import string
import hashlib
import base64

def generate_password(length):
    all_characters = string.ascii_letters + string.digits + string.punctuation
    password = ''.join(random.choice(all_characters) for i in range(length))
    return password

def encrypt_sha256(password):
    return hashlib.sha256(password.encode()).hexdigest()

def encrypt_md5(password):
    return hashlib.md5(password.encode()).hexdigest()

def encrypt_base64(password):
    return base64.b64encode(password.encode()).decode()

def encrypt_aes(password):
    key = b'\x00\x01\x02\x03\x04\x05\x06\x07\x08\x09\x10\x11\x12\x13\x14\x15'
    return hashlib.sha256((password + key.decode()).encode()).hexdigest()

def main():
    print("Password Generator and Encryptor")
    length = int(input("Enter password length (min 8): "))
    
    if length < 8:
        print("Password length must be at least 8 characters")
        return
    
    password = generate_password(length)
    print("Generated Password:", password)
    
    print("Encryption Methods:")
    print("1. SHA-256")
    print("2. MD5")
    print("3. AES")
    print("4. Base64")
    
    choice = input("Enter encryption method (1/2/3/4): ")
    
    if choice == "1":
        encrypted_password = encrypt_sha256(password)
    elif choice == "2":
        encrypted_password = encrypt_md5(password)
    elif choice == "3":
        encrypted_password = encrypt_aes(password)
    elif choice == "4":
        encrypted_password = encrypt_base64(password)
    else:
        print("Invalid choice")
        return
    
    print("Encrypted Password:", encrypted_password)

if __name__ == "__main__":
    main()
