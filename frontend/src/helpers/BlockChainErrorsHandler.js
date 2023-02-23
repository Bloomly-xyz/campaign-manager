const BlockChainErrorsHandler=(TxError,defaultErrMsg)=>{
    let errDescription=TxError?.message !== undefined 
    ?
    TxError?.message?.includes("Declined") 
    ?
    TxError?.message
    :
    TxError?.errorMessage 
    : 
    TxError?.includes("pre-condition failed") 
    ?
    TxError?.split("pre-condition failed:")?.[1]?.split("\n")[0]
    :
    TxError?.includes("[Error Code: 1006]") 
    ?
    TxError?.split("[Error Code: 1006]")?.[1]
    :
    TxError?.includes("[Error Code: 1008]")
    ?
    TxError?.split("[Error Code: 1008]")?.[1]
    :
    TxError?.includes("assertion failed")
    ?
    TxError?.split("assertion failed:")?.[1]?.split("-->")?.[0]
    :
    TxError?.errorMessage?.includes("pre-condition failed") 
    ?
    TxError?.errorMessage?.split("pre-condition failed:")?.[1].split("\n")[0] 
    :
    TxError?.errorMessage 
    ??
    TxError?.message
    ??
    TxError?.split("cadence runtime error:")[1]?.split("\n")[1]
    ??
    TxError?.split("[Error Code: 1006]")?.[1]
    ??
    defaultErrMsg;

    return errDescription;
}
export default BlockChainErrorsHandler;