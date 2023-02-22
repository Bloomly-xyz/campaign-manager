const stringTruncate = (string ,length) => {
  if (string?.length > length){
  return  string?.substr(0, length) +
    "..." 
    
  }else {
   return string
  }
  
  
};

export default stringTruncate;
