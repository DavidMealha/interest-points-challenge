const express         = require('express');
const app             = express();
const bodyParser      = require('body-parser');
const routes          = require('./routes');

app.use('/', routes);
app.use(bodyParser.json());

const port = process.env.PORT || 8080;
app.listen(port, () => {
  console.log("Server Started!");
});


