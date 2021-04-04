function callApi(endpoint, token) {    
    const headers = new Headers();
    const bearer = `Bearer ${token}`;
  
    headers.append("Authorization", bearer);
  
    const options = {
        method: "GET",
        headers: headers
      };   
    
    fetch(endpoint, options)
    .then(response => {
      if(response.ok){
          return response.json();
      }

      return Promise.reject(response);
  })
  
  .then(response => {
    logMessage(response);
  })
  .catch(e => {
      if(e.status === 401){
          // here you are able to do what you need
          // refresh token ..., logout the user ...
          logMessage(e.status + "-" + e.statusText);
      }

      return Promise.reject(e.json());
  });
}