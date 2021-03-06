﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StACS.Core.Exceptions;
using StACS.System.StringExtensions;
using System;

namespace StACS.System.Extensions.UnitTests.StringTests
{
    [TestClass]
    public class EncryptionDecryptionExtensionTests
    {
        private string _decryptedVersion;
        private string _encryptedVersion;
        

        [TestInitialize]
        public void TestSetup()
        {
            _decryptedVersion = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo";
            _encryptedVersion = _decryptedVersion.Encrypt(ConstantStringTestData.ValidKey);
        }

        #region Encrypt Method

        [TestMethod]
        [ExpectedException(typeof(SourceEmptyOrNullException))]
        public void Encrypt_NullString_ValidKey_Exception()
        {
            // Arrange
            string nullString = ConstantStringTestData.NullString;

            // Act
            string actualResult = nullString.Encrypt(ConstantStringTestData.ValidKey);

            // Assert
            Assert.Fail($"Exception should have been thrown.  Actual Result: {actualResult}");
        }

        [TestMethod]
        [ExpectedException(typeof(SourceEmptyOrNullException))]
        public void Encrypt_EmptyString_ValidKey_Exception()
        {
            // Arrange
            string emptyString = ConstantStringTestData.EmptyString;

            // Act
            string actualResult = emptyString.Encrypt(ConstantStringTestData.ValidKey);

            // Assert
            Assert.Fail($"Exception should have been thrown.  Actual Result: {actualResult}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullOrEmptyException))]
        public void Encrypt_ValidString_EmptyKey_Exception()
        {
            // Arrange
            string emptyKey = ConstantStringTestData.EmptyString;

            // Act
            string actualResult = _decryptedVersion.Encrypt(emptyKey);

            // Assert
            Assert.Fail($"Exception should have been thrown.  Actual Result: {actualResult}");
        }

        /// <summary>
        ///     Due to encryption values always changing, the only way to test is to make sure the lengths are identical
        /// </summary>
        [TestMethod]
        public void Encrypt_ValidString_ValidKey_EncryptedString()
        {
            // Arrange
            // Setup as class fields in test class

            // Act
            string actualResult = _decryptedVersion.Encrypt(ConstantStringTestData.ValidKey);

            // Assert
            Assert.AreEqual(_encryptedVersion.Length, actualResult.Length);
        }

        #endregion Encrypt Method

        #region Decrypt Method

        [TestMethod]
        [ExpectedException(typeof(SourceEmptyOrNullException))]
        public void Decrypt_NullString_ValidKey_Exception()
        {
            // Arrange
            string nullString = ConstantStringTestData.NullString;

            // Act
            string actualResult = nullString.Decrypt(ConstantStringTestData.ValidKey);

            // Assert
            Assert.Fail($"Exception should have been thrown.  Actual Result: {actualResult}");
        }

        [TestMethod]
        [ExpectedException(typeof(SourceEmptyOrNullException))]
        public void Decrypt_EmptyString_ValidKey_Exception()
        {
            // Arrange
            string emptyString = ConstantStringTestData.EmptyString;

            // Act
            string actualResult = emptyString.Decrypt(ConstantStringTestData.ValidKey);

            // Assert
            Assert.Fail($"Exception should have been thrown.  Actual Result: {actualResult}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullOrEmptyException))]
        public void Decrypt_ValidString_EmptyKey_Exception()
        {
            // Arrange
            string emptyKey = ConstantStringTestData.EmptyString;

            // Act
            string actualResult = _decryptedVersion.Decrypt(emptyKey);

            // Assert
            Assert.Fail($"Exception should have been thrown.  Actual Result: {actualResult}");
        }

        [TestMethod]
        public void Decrypt_ValidString_ValidKey_DecryptedString()
        {
            // Arrange
            // Setup as class fields in test class

            // Act
            string actualResult = _encryptedVersion.Decrypt(ConstantStringTestData.ValidKey);

            // Assert
            Assert.AreEqual(_decryptedVersion, actualResult);
        }

        #endregion Decrypt Method
    }
}