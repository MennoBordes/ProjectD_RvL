const express = require('express');
const port = 3001;
const app = express();

app.listen(port,()=> console.log(`server started on port ${port}`));