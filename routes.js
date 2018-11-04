const routes = require('express').Router();

routes.get('/api/health', (req, res) => {
  res.status(200).json({ message: 'Connected!' });
});

routes.get('/api/interest-points', (req, res) => {
  res.status(200).json({ result: 'Returning list of interest points!' });
});

routes.get('/api/interest-points/nearest', (req, res) => {
  res.status(200).json({ message: 'Returning closest interest point!' });
});

module.exports = routes;