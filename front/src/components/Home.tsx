import { useEffect, useState } from "react";

export default function Home()
{
    const [users,setUsers]=useState([]);

    useEffect(()=>{
fetch("http://localhost:5174/api/User")
.then(response=>response.json())
.then(data=>setUsers(data))
.catch(err=>console.log("Error"+err));

    },[])
    return (
<>
{users.map(x=>

<h1>{x.id}-{x.userName}</h1>

)}


</>
    );

}