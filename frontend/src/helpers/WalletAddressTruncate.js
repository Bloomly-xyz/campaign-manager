const WalletAddressTruncate = (walletAddress) => {
  if (walletAddress?.length > 5) {
    return (
      walletAddress?.substr(0, 6) +
      "..." +
      walletAddress?.substr(walletAddress?.length - 4, walletAddress?.length)
    );
  } else {
    return walletAddress;
  }
};

export default WalletAddressTruncate;
