import * as fcl from "@onflow/fcl"

fcl.config()
  // connect to Flow testnet
  // for fcl@<1.0.0 this should be https://access-testnet.onflow.org
  .put("accessNode.api", process.env.REACT_APP_ACCESS_NODE)
  
  // use Blocto testnet wallet with HTTP/POST
  .put(
    "discovery.wallet",
    process.env.REACT_APP_DISCOVERY_WALLET
  )
  .put("discovery.wallet.method", process.env.REACT_APP_DISCOVERY_WALLET_METHOD)
  .put(
    "app.detail.icon",
    process.env.REACT_APP_BLOCTO_ICON
  )
  .put("app.detail.title", process.env.REACT_APP_TITLE);